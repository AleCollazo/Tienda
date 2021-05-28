
var modalInsert = {
    props: ['mensaje'],
    methods: {
        cerrar: function (elemento) {
            $(elemento).hide();
        }
    },
    template: 
        `
        <div class="modal" id='modalInsert'>
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <h5 class="modal-title" id="modal-mensaje"></h5>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-dark" v-on:click='cerrar("#modalInsert")'>Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        `
}

var alertInsert = {
    props: ['mensaje', 'show', 'error'],
    template:
    `
    <div class="alert alert-dark" role="alert" v-if="show">
        {{mensaje}}
    </div>
    `
}


var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!'
    },
    components: {
        'modal-insert': modalInsert,
        'alert-insert' : alertInsert
    }
})