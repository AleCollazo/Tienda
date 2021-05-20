var lastScrollTop = 0;

$(document).scroll(function ()
{
    var scrollTop = $(this).scrollTop();
    if (scrollTop < lastScrollTop) {
        $(".navbar").slideDown();
    }
    else {
        $(".navbar").slideUp("slow");
    }
    lastScrollTop = scrollTop;
});


$("#list li").click(function () {
    var $this = $(this); 
    var $children = $this.children(".cbx");
    if ($children.length == 1) {
        var check = $children[0].checked = !$children[0].checked;
    }

    if (check) {
        $this.addClass("active");
    }
    else {
        $this.removeClass("active");
    }
})