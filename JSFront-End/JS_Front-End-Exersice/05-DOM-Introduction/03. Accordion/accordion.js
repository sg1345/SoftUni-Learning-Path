function toggle() {
    let toggleButton = document.querySelector(".button");
    let text = document.getElementById("extra");
    
    console.log(toggleButton);
    
    if(toggleButton.textContent === "More"){
        toggleButton.textContent = "Less";
        text.style.display = "block";
    }
    else{
        toggleButton.textContent = "More";
        text.style.display = "none";
    }
}