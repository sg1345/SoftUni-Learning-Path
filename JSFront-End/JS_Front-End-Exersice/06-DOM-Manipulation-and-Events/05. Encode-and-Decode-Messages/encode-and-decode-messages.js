document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const encodeBtnEl = document.querySelector('#encode button');
    // console.log(encodeBtnEl);
    const decodeBtnEl = document.querySelector('#decode button');
    // console.log(decodeBtnEl);
    
    encodeBtnEl.addEventListener('click', encodeAndSend);
    decodeBtnEl.addEventListener('click', decodeAndRead);

    function encodeAndSend(e) {
        e.preventDefault();
        const formEncodeEl = e.target.parentElement;
        // console.log(formEncodeEl);

        const textarea = formEncodeEl.querySelector('textarea').value;
        // console.log(textarea);

        let encodedMessage = '';
        for (const symbol of textarea) {
            // console.log(symbol.charCodeAt());
            
            const charCodeEncoded = symbol.charCodeAt()+1;

            encodedMessage +=String.fromCharCode(charCodeEncoded);
        }

        // console.log(encodedMessage);
        
        const decodedFormTextareaEl = document.querySelector('#decode textarea');
        decodedFormTextareaEl.value = encodedMessage;

        formEncodeEl.querySelector('textarea').value = '';
    }

    function decodeAndRead(e) {
        e.preventDefault();
        const decodedFormTextareaEl = document.querySelector('#decode textarea');
        // console.log(decodedFormTextareaEl);
        
        const textarea = decodedFormTextareaEl.value;
        // console.log(textarea);
        
        let encodedMessage = '';
        for (const symbol of textarea) {
            // console.log(symbol.charCodeAt());
            
            const charCodeDecoded = symbol.charCodeAt()-1;

            encodedMessage +=String.fromCharCode(charCodeDecoded);
        }

        decodedFormTextareaEl.value = encodedMessage;
    }
    
}