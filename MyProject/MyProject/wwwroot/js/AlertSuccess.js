setTimeout(() => {
    const alert = document.getElementById('alert-success');
if (alert) {
    alert.style.transition = "opacity 0.5s";
alert.style.opacity = "0";
        setTimeout(() => alert.remove(), 500);
    }
}, 3000); // Через 5 секунд
