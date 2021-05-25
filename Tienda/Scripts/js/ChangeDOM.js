
$('.pagination').children().each(function (ind, el) {
    $(el).addClass('page-link');
    el.outerHTML = '<li class="page-item">' + el.outerHTML + '</li>';
});

$('.pagination span.current').parent().addClass('active');