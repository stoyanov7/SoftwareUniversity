function emailValidation(email) {
    let regex = new RegExp(/\b[(a-zA-Z\d._%+)]+@[(a-z)]+\.[a-z]+\b/);

    if(email.match(regex)){
        console.log("Valid");
    }
    else{
        console.log("Invalid");
    }
}