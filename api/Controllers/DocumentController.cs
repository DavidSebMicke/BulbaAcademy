using BulbasaurAPI.Authorization;
using BulbasaurAPI.DTOs.Document;
using BulbasaurAPI.Helpers;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _document;

        public DocumentController(IDocumentRepository context)
        {
            _document = context;
        }

        [HttpGet]
        [Route("/:id")]
        public async Task<ActionResult<DocumentDTO>> GetDocument(int id)
        {
            try
            {
                var user = HttpHelper.GetRequestUser(HttpContext);

                var document = await _document.GetById(id);

                if (document == null) return NotFound();

                if (document.UploadedBy.Id == user.Id ||
                    document.EligibleList.Contains(user) ||
                    document.EligibleGroups.Any(g => g.People.Any(u => u.Id == user.Id)))
                {
                    var file = PDFUtils.GetFile(document);
                    if (file == null) return NotFound("The PDF file was not found.");

                    var dto = new DocumentDTO(document, file);

                    return Ok(dto);
                }

                return Unauthorized("You are not authorized to view this file.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<DocumentDTO[]>> GetAllDocuments()
        {
            try
            {
                var user = HttpHelper.GetRequestUser(HttpContext);

                var documents = await _document.GetAll();

                var documentList = documents.ToList();
                if (!documentList.Any()) return NotFound("No documents on the server");

                List<DocumentDTO> returnDocuments = new();

                foreach (var document in documentList)
                {
                    if (document.UploadedBy.Id == user.Id ||
                        document.EligibleList.Contains(user) ||
                        document.EligibleGroups.Any(g => g.People.Any(u => u.Id == user.Person.Id)))
                    {
                        var file = PDFUtils.GetFile(document);
                        if (file == null) continue;

                        var dto = new DocumentDTO(document, file);

                        returnDocuments.Add(dto);
                    }
                }

                if (!returnDocuments.Any()) return NotFound("You don't have access to any documents.");

                return Ok(returnDocuments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> CreateDocument(IncomingDocumentDTO incomingDocument)
        {
            try
            {
                var user = HttpHelper.GetRequestUser(HttpContext);

                // Construct and get paths for file
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                string folderPath = $"{projectDirectory}/{user.Id}";
                string filePath = $"{folderPath}/{incomingDocument.DocumentFileName}";

                var successfullySaved = PDFUtils.SaveFile(incomingDocument.Document, filePath);

                if (!successfullySaved) return Problem("Could not save the PDF file.");

                List<User> eligibleUsers = new();
                List<Group> eligibleGroups = new();

                if (incomingDocument.EligibleUserIds != null)
                    eligibleUsers = await _document.GetUsersById(incomingDocument.EligibleUserIds);

                if (incomingDocument.EligibleGroupIds != null)
                    eligibleGroups = await _document.GetGroupsById(incomingDocument.EligibleGroupIds);

                Document newDocument = new(incomingDocument, folderPath, eligibleUsers, eligibleGroups, user);

                var returnDocument = _document.Create(newDocument);

                return Ok(returnDocument);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/:id")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            try
            {
                var user = HttpHelper.GetRequestUser(HttpContext);
                if (!await _document.EntityExists(id)) return NotFound("No document found with the given id.");
                var document = await _document.GetById(id);

                if (document.UploadedBy.Id == user.Id || user.AccessLevel > UserAccessLevel.SEMIADMIN)
                {
                    PDFUtils.DeleteFile(document.FilePath);
                    await _document.Delete(document);
                    return Ok("Document deleted successfully.");
                }
                else
                {
                    return Unauthorized("You do not have permission to delete this document.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}