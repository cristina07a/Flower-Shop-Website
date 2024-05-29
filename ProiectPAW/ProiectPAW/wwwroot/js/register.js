function solve(event) { 
    event.preventDefault(); 
    let password = document.getElementById('password').value; 
    let repassword = document.getElementById('repassword').value; 
    let mobile = document.getElementById('mobile').value; 
    let mail = document.getElementById('email').value; 
    let pass = document.getElementById('pass'); 
    let flag = true; 
    let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; 
  
    if (!emailRegex.test(mail)) { 
        flag = false; 
        pass.innerText = 'Te rog introdu o adresă de email validă.'; 
        setTimeout(() => { 
            pass.innerText = ""; 
        }, 3000); 
    } 
  
    if (password !== repassword) { 
        flag = false; 
        pass.innerText = "Parolele nu coincid. Te rog reintrodu."; 
        setTimeout(() => { 
            pass.innerText = ""; 
        }, 3000); 
    } 
  
    let passwordRegex = /^(?=.*\d)(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9])\S{8,}$/; 
  
    if (!passwordRegex.test(password)) { 
        flag = false; 
        pass.innerText = 'Parola trebuie să aibă cel puțin 8 caractere și să includă cel puțin o cifră, o literă și un simbol.'; 
        setTimeout(() => { 
            pass.innerText = ""; 
        }, 3000); 
    } 
    if (flag) {
        alert("Formular trimis"); 
        window.location.href = "cont.html";
    }
}
