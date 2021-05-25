
$('.pagination').children().each(function (ind, el) {
    $(el).addClass('page-link').addClass('text-dark');
    el.outerHTML = '<li class="page-item">' + el.outerHTML + '</li>';
});

$('.pagination span.current').removeClass('text-dark').addClass('bg-secondary').addClass('text-white');