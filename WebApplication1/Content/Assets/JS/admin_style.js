function editTopic(that) {
    document.getElementById('InsUpdForm').action = '/TopicManager/UpdateTopic';
    document.getElementById('PK_iMaLoaiTin').value = that.value;
    document.getElementById('sTenLoaiTin').value = that.getAttribute('data-name');
    document.getElementById('iViTri').value = that.getAttribute('data-vitri');
    document.getElementById('iSTT').value = that.getAttribute('data-stt');
	document.getElementById('submit').value = 'update';
	document.getElementById('submit').innerHTML = 'Cập nhật';
	document.getElementById('cancel').classList.remove('hidden');
}
function cancelEdit(that) {
    document.getElementById('InsUpdForm').action = '/TopicManager/AddTopic';
    that.classList.add('hidden');
    document.getElementById('PK_iMaLoaiTin').value = '';
    document.getElementById('sTenLoaiTin').value = '';
    document.getElementById('iViTri').value = 1;
    document.getElementById('iSTT').value = '';
    document.getElementById('submit').value = 'add';
    document.getElementById('submit').innerHTML = 'Thêm';
}

//----------------------------EditAccount
function EditAccount(that) {
    document.InsUpdForm.action = '/AccountManager/UpdateAccount';
    document.getElementById('PK_iMaTK').value = that.value;
    document.getElementById('sUsername').value = that.getAttribute('data-name');
    document.getElementById('sUsername').setAttribute('disabled', true);
    document.getElementById('sPassword').setAttribute('placeholder', 'Có thể bỏ trống');
    document.getElementById('FK_iMaQuyen').value = that.getAttribute('data-q');
    document.getElementById('submit').value = 'update';
    document.getElementById('submit').innerHTML = 'Cập nhật';
    document.getElementById('cancel').classList.remove('hidden');
}
function cancelEditAccount(that) {
    document.InsUpdForm.action = '/AccountManager/InsertAccount';
    that.classList.add('hidden');
    document.getElementById('PK_iMaTK').value = '';
    document.getElementById('sUsername').value = '';
    document.getElementById('sUsername').removeAttribute('disabled');
    document.getElementById('sPassword').removeAttribute('placeholder');
    document.getElementById('submit').value = 'add';
    document.getElementById('submit').innerHTML = 'Thêm';
}
//EditAccount----------------------------
//-----------------------modal
var modal = document.getElementById("myModal");

function OpenModal() {
    modal.style.display = "block";
}
document.getElementById("closeModal").onclick = function () {
    modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
//end modal-----------------------
//------------------------checkpass
function Check() {
    var btn = document.getElementById("btnConfirmCP");
    var newpass = document.getElementById("newPass").value;
    var renewpas = document.getElementById("renewPass").value;
    var message = document.getElementById("warningPass");
    if (newpass == renewpas) {
        btn.setAttribute("type", "submit");
        message.classList.add("hidden");
        return true;
    }
    else {
        message.classList.remove("hidden");
        return false;
    }
}
//checkpass------------------------