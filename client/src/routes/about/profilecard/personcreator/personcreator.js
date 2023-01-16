export default ThisPersonDoesNotExist = () => {
	async function getBase64(body, mimType, width, height) {
		let resizedImageBuffer = await sharp(body).resize(width, height).toBuffer();
		let resizedImageData = resizedImageBuffer.toString('base64');
		let resizedBase64 = `data:${mimType};base64,${resizedImageData}`;
		return resizedBase64;
	}

	async function getRemoteImage() {
		return new Promise((resolve, reject) => {
			request.get(
				{
					url: 'https://thispersondoesnotexist.com/image',
					encoding: null
				},
				(error, response, body) => {
					if (error) return reject(error);
					try {
						if (response.statusCode == 200) {
							let img = new (body, 'base64')();
							let mimType = response.headers['content-type'];
							resolve({
								img,
								mimType
							});
						} else {
							throw error;
						}
					} catch (e) {
						reject(e);
					}
				}
			);
		});
	}
	async function getImage({ width, height, type, path }) {
		width = width || 128;
		height = height || 128;
		type = type || 'file';
		path = path || '.';

		try {
			let { img, mimType } = await this.getRemoteImage();

			if (img && mimType) {
				let response;

				response = await this.getBase64(img, mimType, width, height);

				return {
					status: true,
					data: response
				};
			} else {
				throw error;
			}
		} catch (error) {
			throw error;
		}
	}
};
