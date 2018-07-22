(function ($) {
    function AttributeValue() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-attribute-value").on('loaded.bs.modal', function (e) {
            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new AttributeValue();
        self.init();
    })
}(jQuery))
