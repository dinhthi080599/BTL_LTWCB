document.getElementById('collapseBtn').onclick = function() {
	this.classList.toggle('btn-light');
	document.getElementById('collapseIcon').classList.toggle('fa-times');
	document.getElementById('wrapper').classList.toggle('slide');
}

window.onscroll = function () {
	var btn = document.getElementById('btn-to-top');
	document.body.scrollTop > 20 || document.documentElement.scrollTop > 20 ? btn.classList.remove('hidden') : btn.classList.add('hidden');
}