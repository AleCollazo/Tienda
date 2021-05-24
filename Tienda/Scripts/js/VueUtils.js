Vue.component('modal-insert', {
    props: ['mensaje'],
    template: 
        `
        <div class="modal" id='modalInsert'>
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        {{mensaje}}
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-dark" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        `
})

var app = new Vue({
    el: '#app',
    methods: {
        showInsertModal: function () {
            $('#modalInsert').modal('show')
        }
    }
})