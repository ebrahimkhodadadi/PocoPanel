
//back to top
var btn = $('#button');
$(window).scroll(function() {
  if ($(window).scrollTop() > 300) {
	btn.addClass('show');
  } else {
	btn.removeClass('show');
  }
});

btn.on('click', function(e) {
  e.preventDefault();
  $('html, body').animate({scrollTop:0}, '300');
});


// Initialize All Required DOM Element
const rippleAnimation = document.querySelectorAll(".ripple");

// Initialize Ripple Animation on Button Click
rippleAnimation.forEach((button) => {
	button.addEventListener("click", function (e) {
		const x = e.clientX;
		const y = e.clientY;

		const buttonTop = e.target.offsetTop;
		const buttonLeft = e.target.offsetLeft;

		const xInside = x - buttonLeft;
		const yInside = y - buttonTop;

		const btnCircle = document.createElement("span");

		btnCircle.classList.add("btn-circle");
		btnCircle.style.top = yInside + "px";
		btnCircle.style.left = xInside + "px";

		this.appendChild(btnCircle);
		setTimeout(() => btnCircle.remove(), 500);
	});
});
