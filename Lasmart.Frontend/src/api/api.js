class Client {
    baseUrl 

    constructor(baseUrl) {       
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : '';
    }
    
    GetAllPoints() {
      let url = this.baseUrl + '/api/Point/GetAll'; 

      $.get(url, function (data) {
        drawAllPoints(data);
      });
    }

    //Points

    CreatePoint(CreatePointDto) {
      let url = this.baseUrl + '/api/Point/Create';  

      $.post(url, CreatePointDto, 
        function(data){
          //alert("Точка добавлена!");
          drawNewPoint(data);
        }).fail(function(exception){
          alert('Операция добавления точки прервана!\n ' + JSON.stringify(exception.responseJSON.errors)); 
        });
    }

    UpdatePoint(UpdatePointDto) {
      let url = this.baseUrl + '/api/Point/Update';

      $.ajax({
        url: url,
        type: 'PUT',
        data: UpdatePointDto,
        success: function(result) {
          //alert("Точка обновлена!");          
        }
      }).fail(function(exception){
          alert('Операция редактирования точки прервана!\n ' + JSON.stringify(exception.responseJSON.errors));           
        });
    }

    DeletePoint(id) {
      let url = this.baseUrl + '/api/Point/Delete' + '?id=' + id;

      $.ajax({
        url: url,
        type: 'DELETE',        
        success: function(result) {
          //alert("Точка удалена!");
        }
      }).fail(function(exception){
          alert('Операция удаления точки прервана!\n ' + JSON.stringify(exception.responseJSON.error)); 
        });

    }

    //Comments
    CreateComment(CreateCommentDto) {
      let url = this.baseUrl + '/api/Comment/Create';  

      $.post(url, CreateCommentDto, 
        function(data){
          //alert("Комментарий добавлен!");         
           drawNewComment(data, CreateCommentDto);           
        }).fail(function(exception){
          alert('Операция добавления комментария прервана!\n ' + JSON.stringify(exception.responseJSON.errors)); 
        });
    }

    UpdateComment(UpdateCommentDto) {
      let url = this.baseUrl + '/api/Comment/Update';

      $.ajax({
        url: url,
        type: 'PUT',
        data: UpdateCommentDto,
        success: function(result) {
          //alert("Комментарий отредактирован!");
        }
      }).fail(function(exception){
          alert('Операция редактирования комментария прервана!\n ' + JSON.stringify(exception.responseJSON.errors));           
        });
    }

    DeleteComment(id) {
      let url = this.baseUrl + '/api/Comment/Delete' + '?id=' + id;

      $.ajax({
        url: url,
        type: 'DELETE',        
        success: function(result) {
          //alert("Комментарий удален!");
        }
      }).fail(function(exception){
          alert('Операция удаления комментария прервана!\n ' + JSON.stringify(exception.responseJSON.error)); 
        });

    }
}