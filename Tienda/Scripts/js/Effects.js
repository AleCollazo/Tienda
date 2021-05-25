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
        var $colldata = $('#coll-data-' + $children.attr('name'));

        if (check) {
            $this.addClass("active");
            if ($colldata.length == 1) $colldata.show('slow');
        }
        else {
            $this.removeClass("active");
            if ($colldata.length == 1) $colldata.hide('slow');
        }
    }
})

$("#list li").mouseenter(function () {
    $(this).addClass('bg-light');
})

$("#list li").mouseleave(function () {
    $(this).removeClass('bg-light');
})