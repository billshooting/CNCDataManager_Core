/** 显示页面加载，使页面看起来在响应 */
(function Loading() {
    let progressBar = document.getElementById('loading-progress-bar');
    let container = document.getElementById('loading-progress-container');
    let value = 0;
    let id = setInterval(() => {
        if(value < 85) value += 2.5;
        progressBar.style.width = value.toString() + '%';
   }, 200);
    document.addEventListener("DOMContentLoaded",() => {
        clearInterval(id);
        value = 100;
        progressBar.style.width = value.toString() + '%';
        setTimeout(() => document.body.removeChild(container), 1000);
    });
}());

