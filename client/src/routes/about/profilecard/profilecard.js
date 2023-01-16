// async function sleep(duration) {
//     return new Promise(() => {
//         setTimeout(() => duration);
//     });
// }
// async function Image() {
//     let image;
//     await fetch('https://thispersondoesnotexist.com/image', {
//         mode: 'no-cors',
//         cache: 'reload'
//     })
//         .then((response) => response.text)
//         .then((html) => {
//             image = html;
//         });
//     return image;
// }
