// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//import { createApp } from 'vue'

//let app = new Vue({
//    el: '#app',
//    data: {
//        message: `Vue in the works!`
//    }
//})

/*app.mount('#app')*/

//Sweet Alert



function displayAlert() {
    Swal.fire("Sweet alert example");
}

function createForm(e) {

    e.preventDefault();

    Swal.fire({
        title: 'Apakah data sudah sesuai',
        icon: 'question',
        showCancelButton: true
    }).then(result => {
        if (result.isConfirmed) {
            const myForm = document.getElementById('myForm');
            myForm.submit();
        }
    })
}

function editForm(e) {

    e.preventDefault();

    Swal.fire({
        title: 'Update data?',
        icon:'question',
        type: 'question',
        showCancelButton: true
    }).then(result => {
        if (result.isConfirmed) {
            const myForm = document.getElementById('myForm');
            myForm.submit();
        }
    })
}

function deleteForm() {


    Swal.fire({
        title: 'Data berhasil dihapus',
        icon: 'Success',
    })
}