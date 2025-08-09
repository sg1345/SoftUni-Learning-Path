function passwordValidator(password){

    let isPasswordValid = true;

    if(!validPasswordLength(password)){
        isPasswordValid = false;
        console.log("Password must be between 6 and 10 characters");       
    }

    if(!hasOnlyLettersAndDigits(password)){
        isPasswordValid = false;
        console.log("Password must consist only of letters and digits");       
    }

    if(!hasAtleastTwoDigits(password)){
        isPasswordValid = false;
        console.log("Password must have at least 2 digits");        
    }

    if(isPasswordValid){
        console.log("Password is valid");
        
    }

    function validPasswordLength(password){

        if(password.length < 6 || password.length > 10){
            return false;
        }
        else{
            return true;
        }
    }

    function hasOnlyLettersAndDigits(password){
        return /^[A-Za-z0-9]+$/.test(password);
    }

    function hasAtleastTwoDigits(password){
        let pattern = /[0-9]/g;

        let matches = password.match(pattern);

        if(matches === null){
            return false
        }

        if(matches.length >= 2){
            return true;
        }
        else{
            return false;
        }
    }
}

passwordValidator('logIn');
passwordValidator('MyPass123');
// passwordValidator('Pa$s$s');