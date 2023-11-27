const btnSignIn = document.getElementById("sign-in"),
      btnSignUp = document.getElementById("sign-up"),
      formRegister = document.querySelector(".register"),
      formLogin = document.querySelector(".login");

btnSignIn.addEventListener("click",e =>{
    formRegister.classList.add("hide");
    formLogin.classList.remove("hide");
})
btnSignUp.addEventListener("click",e =>{
    formRegister.classList.remove("hide");
    formLogin.classList.add("hide");
})
function redirectToLogin() {
    window.location.href = 'stock.html';
}