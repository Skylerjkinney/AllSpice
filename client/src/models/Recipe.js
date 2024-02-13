export class Recipe {
    constructor(data) {
        this.image = data.image
        this.title = data.title
        this.instructions = data.instructions
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.id = data.id
    }
}