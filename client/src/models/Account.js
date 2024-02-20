export class Account {
	constructor(data) {
		this.id = data.id;
		this.email = data.email;
		this.number = data.number;

		this.name = data.name;
		this.picture = data.picture;
		this.coverImg = data.coverImg;
		this.bio = data.bio;
		this.gitHub = data.gitHub;
		this.linkedIn = data.linkedIn;
	}
}
