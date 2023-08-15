var counter = 0;

function spawnComment(guid, counter, comment, counterOfIndent){
    let coord_x = 0;
    let coord_y = 0;
    let radius = 0;

    pointsLayer.children.forEach((element) => {      
       if(element.attrs.guid == comment.pointID){
           coord_x = element.attrs.x - 125/2;
           coord_y = element.attrs.y;
           radius = element.attrs.radius;           
       }
    });  

    let commentCounter = 0;   
    commentsLayer.children.forEach((element) => {
       if(element.attrs.PointID == comment.pointID){
           commentCounter++;
       }
    });

	var rectangle = new Konva.Group({
		x: coord_x, 
        y: coord_y + (radius + 3) + commentCounter * 25 + (8 * counterOfIndent), 
        width: 135,
        height: 30,         
        draggable: true,
        guid: guid,
    	id: counter,
        PointID: comment.pointID,        
    }); 

    rectangle.add(new Konva.Rect({    	
        width: 135,
        height: 30,
        fill: comment.backgroundColor,
        guid: guid,
    	id: counter,       
    }));

    rectangle.add(new Konva.Text({
        text: comment.text,
        fontSize: 18,
        padding: 6,
        fontFamily: 'sans-serif',
        fill: '#ffffff',
        width: 130,      
        align: 'center',  
        guid: guid,
    	id: counter,              
    }));    

    rectangle.on('dblclick', function(evt) {       	 
    	myClient.DeleteComment(evt.target.attrs.guid);
    	rectangle.destroy();    	
    });

    rectangle.on('contextmenu', function(evt) {         
        alert("Номер комментария: " + evt.target.attrs.id);       
    });

    commentsLayer.add(rectangle);    
}

function drawNewComment(guid, comment){    
	counter++;  
	spawnComment(guid, counter, comment, 1);
}

function drawAllComments(guid, data){
    var counterOfIndent = 0;    	
	data.forEach((element) => {
        counter++;
        counterOfIndent++;        
        spawnComment(element.id, counter, element, counterOfIndent);
	}); 	
}