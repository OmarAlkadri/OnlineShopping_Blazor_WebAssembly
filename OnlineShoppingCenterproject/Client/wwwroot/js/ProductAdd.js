function add() {
	jQuery(document).ready(function ($) {
		$('.buy').on('click', function (e) {
			e.preventDefault();

			$('body').addClass('expanded');
			setTimeout(() => $('body').removeClass('expanded'),1000);
		})
	});
}