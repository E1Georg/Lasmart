var counterPoints = 0;

function spawnPoint(guid, counter, x, y, Radius, Color){
	var circle = new Konva.Group({
		x: x !== undefined && x !== null ? x : 510, 
        y: y !== undefined && y !== null ? y : 165, 
        radius: Radius !== undefined && Radius !== null ? Radius : 25,        
        draggable: true,
        guid: guid,
    	id: counter,
    }); 

    circle.add(new Konva.Circle({    	
        radius: Radius !== undefined && Radius !== null ? Radius : 25,  
        fill: Color !== undefined && Color !== null ? Color : "red", 
        stroke: 'black',
        strokeWidth: 2,
        guid: guid,
    	id: counter,
    }));

    circle.add(new Konva.Text({
        text: counter,
        fontSize: 18,
        fontFamily: 'sans-serif',
        fill: '#ffffff',
        width: 130,      
        align: 'left',  
        guid: guid,
    	id: counter,      
    }));  

    circle.on('dragend', function(evt) {

    	let UpdatePointDto_model = new UpdatePointDto(
	    	evt.target.children[0].attrs.guid,
	    	evt.target._lastPos.x,
	    	evt.target._lastPos.y,
	    	evt.target.children[0].attrs.radius,
	    	evt.target.children[0].attrs.fill
	    );

	    myClient.UpdatePoint(UpdatePointDto_model);

        
        let tmp_counter = -1;

        commentsLayer.children.forEach((element) => {   
            if(element.attrs.PointID == evt.target.children[0].attrs.guid){
                tmp_counter++;
                element.position({
                    x: evt.target._lastPos.x - 125/2,
                    y: evt.target._lastPos.y + (evt.target.children[0].attrs.radius + 3) + tmp_counter * 25 + (8 * tmp_counter)
                })  
            }
        });	
        commentsLayer.batchDraw();
    });

    circle.on('dblclick', function(evt) {    	 
    	myClient.DeletePoint(evt.target.attrs.guid);
    	circle.destroy();    	
    });

    pointsLayer.add(circle);    
}

function drawNewPoint(guid){
	counterPoints++;		
	spawnPoint(guid, counterPoints);
}

function drawAllPoints(data){	
	data.points.forEach((element) => {
		counterPoints++;
		spawnPoint(element.id, counterPoints, element.x, element.y, element.radius, element.color);        
        drawAllComments(element.id, element.comments);
	}); 	
}