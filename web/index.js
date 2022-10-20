var form = document.querySelector('#note-form');

form.addEventListener('submit', event => {
    event.preventDefault();

    var formData = new FormData();
    const files = event.target.images.files;
    for (let i = 0; i < files.length; i++) {
        formData.append("images", files[i]);
    }
    formData.append("noteContent", event.target.note.value);
    formData.append("number", event.target.number.value);


    fetch('https://localhost:7241/api/Image/Upload', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(result => {
            if (result.errorMessage) {
                alert(result.errorMessage);
                return;
            } else {
                console.log(result);
            }
        })
        .catch((error) => alert(error));
});