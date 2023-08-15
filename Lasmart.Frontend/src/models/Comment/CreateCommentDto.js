class CreateCommentDto {
    pointID
    text
    backgroundColor

    constructor(pointID, text, backgroundColor) {
        this.pointID = pointID;
        this.text = text;
        this.backgroundColor = backgroundColor;
    }    
}