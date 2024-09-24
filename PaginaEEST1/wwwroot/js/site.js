function downloadImage(imageSrc, fileName) {
    var link = document.createElement('a');
    link.href = imageSrc;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function printImage(imageSrc) {
    var printWindow = window.open('', '_blank');
    printWindow.document.write('<img src="' + imageSrc + '" onload="window.print();window.close();" />');
    printWindow.document.close();
}