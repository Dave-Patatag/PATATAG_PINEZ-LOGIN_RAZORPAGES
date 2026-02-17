document.querySelectorAll(".toggle-password").forEach(function (eyeIcon) {
    eyeIcon.addEventListener("click", function () {
        // Find the input inside the same wrapper
        const input = this.closest(".password-wrapper").querySelector("input");

        this.classList.toggle("fa-eye");
        this.classList.toggle("fa-eye-slash");

        input.type = input.type === "password" ? "text" : "password";
    });
});
