class UpdateCommentDto {
    ID
    PointID
    Text
    BackgroundColor

    constructor(ID, PointID, Text, BackgroundColor) {
        this.ID = ID;   
        this.PointID = PointID;
        this.Text = Text;
        this.BackgroundColor = BackgroundColor;
    }    
}