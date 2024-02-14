export class Recipe {
    constructor(data) {
        this.img = data.img
        this.title = data.title
        this.instructions = data.instructions
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.id = data.id
    }
}