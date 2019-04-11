var dotsRow = 15;  //get from server with AJAX
var dotsColumn = 17; //get from server with AJAX
var dotRadius = 8; //
var dotSpacing = 50;
var xPadding = 75;
var yPadding = 75;
var lineWidth = 3;
var animationDuration=1;  
var canvas = document.getElementById('canvas');
var canvasHeight = canvas.height;
var canvasWidth = canvas.width;
var dot = [];
var defaultColor='green';
var capturedByPlayer1Color='red';
var capturedByPlayer2Color='blue';
for(var c=0; c<dotsColumn; c++) {
    dot[c] = [];
    for(var r=0; r<dotsRow; r++) {
        dot[c][r] = { 
		x: xPadding + c*dotSpacing, 
		y: yPadding + r*dotSpacing, 
		isCapturedBy: 0,		}; //replace "isCapturedBy" with something else
    }
}




function drawTable() //creates a net of lines 
{
	for (c=0;c<dotsColumn;c+=1)
	{$('canvas').drawLine(
	{   //draw vertical line
				strokeStyle: 'black',
				layer: true,
				strokeWidth: lineWidth,
				x1: c*dotSpacing + xPadding, y1: yPadding,
				x2: c*dotSpacing + xPadding, y2: yPadding + dotSpacing*(dotsRow-1)
	});
	};

		for (r=0;r<dotsRow;r+=1)
		{
			$('canvas').drawLine(
			{  //draw horizontal line
			strokeStyle: 'black',
				strokeWidth: lineWidth,
				layer:true,
				x1: xPadding, y1: r*dotSpacing + yPadding,
			x2: xPadding + dotSpacing*(dotsColumn-1), y2: r*dotSpacing + yPadding
			});
		}
}
function drawDots()  //creates dots in their positions defined in (dots) array
{
	for (c=0;c<dotsColumn;c+=1)
	{
		for (r=0;r<dotsRow;r+=1)
		{
			if (dot[c][r].isCapturedBy===2)
				arcColor=capturedByPlayer2Color;
			else if (dot[c][r].isCapturedBy===1)
				arcColor=capturedByPlayer1Color;
			else arcColor='green';
			$('canvas').drawArc(
			{  //draw dot
			fillStyle: arcColor,
			layer:true,
			x: dot[c][r].x, y: dot[c][r].y,
			data: {gridRow: r, gridColumn: c},
			radius: dotRadius,
			click: function captureHandler(layer)
			{
				dot[$('canvas').getLayer(layer).data.gridColumn][$('canvas').getLayer(layer).data.gridRow].isCapturedBy=1; //updates dot's state ; send new state to server with AJAX
				drawDots();
			} //clickEnd
			});  
		/* draw line logic: if the dot above on the left, right or above is captured AND the new dot is captured, 
		draw a line between captured dots 
		: don't draw if adjacent dots are captured?
		new draw logic - if the dot is surrounded by captured dots, draw lines between captured dots : think through line logic once more
		to prevent useless lines from being drawn
		
		*/
		
		
		/* new ideas - draw lines regardless of whether a zone is present or not; dot becomes owned if 
		
		
		*/
		if (c>0 && r>0 && dot[c-1][r-1].isCapturedBy===1 && dot[c][r].isCapturedBy===1) //executes if the dot in the top-left or bottom-right is captured
		{
		$('canvas').drawLine(
			{  //connect dots with a line
			strokeStyle: capturedByPlayer1Color,
				strokeWidth: lineWidth+1,
				layer:true,
				x1: dot[c-1][r-1].x, y1: dot[c-1][r-1].y,
				x2: dot[c][r].x, y2: dot[c][r].y
			});
		}
		if (c>0 && r<dotsRow-1 && dot[c-1][r+1].isCapturedBy===1 && dot[c][r].isCapturedBy===1) //executes if the dot in the top-right or bottom-left is captured
		{
		$('canvas').drawLine({  //connect dots with a line
			strokeStyle: capturedByPlayer1Color,
				strokeWidth: lineWidth+1,
				layer:true,
				x1: dot[c-1][r+1].x, y1: dot[c-1][r+1].y,
		x2: dot[c][r].x, y2: dot[c][r].y});
		}
		
		} //for(r) end
	} //for(c) end
}//function end
drawTable();
drawDots();
