//Icon
function img_pathUrl(input) {
        $('#file-preview')[0].src = (window.URL ? URL : webkitURL).createObjectURL(input.files[0]);
}
//Multi Images
let filesData = []; // Array to store file data
const fileInput = document.getElementById('file-input');

document.getElementById('file-input').addEventListener('change', function (event) {
    const files = event.target.files;
    const previewContainer = document.getElementById('preview-container');
    previewContainer.innerHTML = ''; // Clear previous previews

    filesData = []; // Clear previous file data

    for (let i = 0; i < files.length; i++) {
        const file = files[i];
        if (!file.type.match('image.*')) {
            continue; // Skip non-image files
        }

        const reader = new FileReader();
        reader.onload = function (event) {
            const img = document.createElement('img');
            img.src = event.target.result;
            img.classList.add('preview-image');

            // Create delete button
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.classList.add('delete-button');
            deleteButton.addEventListener('click', function () {
                const index = filesData.findIndex(item => item.file === file);
                if (index !== -1) {
                    previewContainer.removeChild(filesData[index].previewItem); // Remove corresponding preview item
                    filesData.splice(index, 1); // Remove file data from filesData array
                    removeFileFromInput(file); // Remove file from input
                }
            });

            // Create container for image and delete button
            const previewItem = document.createElement('div');
            previewItem.classList.add('preview-item');
            previewItem.appendChild(img);
            previewItem.appendChild(deleteButton);

            // Append preview item to preview container
            previewContainer.appendChild(previewItem);

            // Store file data
            filesData.push({ file, previewItem });
        }
        reader.readAsDataURL(file);
    }
});

// Function to remove file from input
function removeFileFromInput(fileToRemove) {
    const newFiles = Array.from(fileInput.files).filter(file => file !== fileToRemove);
    const newFileList = new DataTransfer();
    newFiles.forEach(file => newFileList.items.add(file));
    fileInput.files = newFileList.files;
}