function BlazorDownloadFile(fileName, contentType, content) {
    // Convert content from base64 to binary data
    const binaryData = atob(content);

    // Create a new blob object
    const blob = new Blob([binaryData], { type: contentType });

    // Create a temporary URL to the blob
    const url = URL.createObjectURL(blob);

    // Create a link element to trigger the download
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    // Revoke the URL to free up memory
    URL.revokeObjectURL(url);
}



