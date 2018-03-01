
(function($) {

	skel.breakpoints({
		wide: '(max-width: 1680px)',
		normal: '(max-width: 1280px)',
		narrow: '(max-width: 980px)',
		narrower: '(max-width: 840px)',
		mobile: '(max-width: 736px)',
		mobilep: '(max-width: 480px)'
	});

	$(function() {

		var	$window = $(window),
			$body = $('body');

		// Disable animations/transitions until the page has loaded.
			$body.addClass('is-loading');

			$window.on('load', function() {
                $body.removeClass('is-loading');
                $('.checkin-date').click(dateFix);
                $('.checkin-date').blur(dateFix);
			    $('#datetimepicker6').datetimepicker();
			    $('#datetimepicker7').datetimepicker({
			        useCurrent: false //Important! See issue #1075
			    });
			    $("#datetimepicker6").on("dp.change", function (e) {
			        $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
			    });
			    $("#datetimepicker7").on("dp.change", function (e) {
			        $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
                });
			});

            function dateFix() {
                var cd = $(".checkin-date").val();
                console.log(cd);
                $('.checkin-date').attr('value', cd);
	            $('.checkout-date').attr('min', cd);
	        }
		// Fix: Placeholder polyfill.
			$('form').placeholder();

		// Prioritize "important" elements on narrower.
			skel.on('+narrower -narrower', function() {
				$.prioritize(
					'.important\\28 narrower\\29',
					skel.breakpoint('narrower').active
				);
			});

		// Dropdowns.
			$('#nav > ul').dropotron({
				offsetY: -15,
				hoverDelay: 0,
				alignment: 'center'
			});

		// Off-Canvas Navigation.

			// Title Bar.
				$(
					'<div id="titleBar">' +
						'<a href="#navPanel" class="toggle"></a>' +
						'<span class="title"> Dream Hotel </span>' +
					'</div>'
				)
					.appendTo($body);

			// Navigation Panel.
				$(
					'<div id="navPanel">' +
						'<nav>' +
							$('#nav').navList() +
						'</nav>' +
					'</div>'
				)
					.appendTo($body)
					.panel({
						delay: 500,
						hideOnClick: true,
						hideOnSwipe: true,
						resetScroll: true,
						resetForms: true,
						side: 'left',
						target: $body,
						visibleClass: 'navPanel-visible'
					});

			// Fix: Remove navPanel transitions on WP<10 (poor/buggy performance).
				if (skel.vars.os == 'wp' && skel.vars.osVersion < 10)
					$('#titleBar, #navPanel, #page-wrapper')
						.css('transition', 'none');

	});

})(jQuery);
