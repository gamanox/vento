function display_from_url(e,form)
{
    e.preventDefault();
    var req = $.ajax({
        type: 'POST',
        contentType: "application/x-www-form-urlencoded;charset=UTF-8",
        url: form.attr("action"),
        data: form.serialize(),
        dataType: "json"
    });
    req.complete(function(data) {
        $("#shady_layer").css("width","100%");
        $("#shady_layer").css("height","100%");
        $("#shady_layer").css("display","block");
        $("#newcontent").css("display","block");
        $("#newcontent").html(data['responseText']);
        $("#newcontent").append('<div id="closer_text" class="closertext" onclick="javascript:close_layers()"></div>');
    });
    $(".closertext").click(function(){
        alert("close");
        close_layers();
    });
}
function close_layers()
{$("#shady_layer").css("display","none");
    $("#newcontent").html("");
    $("#newcontent").css("display","none");	}
$(document).ready(function () {
    $("body").append('<div id="shady_layer" class="shady_layer"><div id="newcontent" class="new_layer"></div></div>');
    $("body").prepend('<style> body {overflow-y:hidden;overflow-x:hidden;} #shady_layer{width: 100%; height: 100%; display: block; top: 0; z-index: 10000; background-color: rgba(0,0,0,.5); position: fixed; display: none; } #newcontent{width: 880px; height: 880px; display: block; z-index: 15000; margin: 0 auto; background: #fff; z-index: 15000; position:relative; } .popup{position: relative; } .closertext{position: absolute; width: 42px; height: 42px; top: 0px; background: url(../img/icons/cerrar_popup.png ) no-repeat scroll 0 0 #009ddc; z-index: 1000000; right: -47px; cursor: pointer; top: 0; } .closertext:hover{background-color: #0872ae; } </style>');
    $(".chackbox_880").click(function (e) {
        e.preventDefault();
        $("#newcontent").load(
	  		$(this).attr("href"),
	  		function () {
	  		    $("#newcontent").append('<div id="closer_text" class="closertext" onclick="javascript:close_layers()"></div>');
	  		}
	  	);
        $("#newcontent").css("width", "880px");
        $("#newcontent").css("height", "880px");
        $("#shady_layer").css("display", "block");
        $("#newcontent").css("display", "block");
    });
});