const loading_indicator = document.querySelector("#loading-indicator");
const loading_warning = document.querySelector("#loading-warning");

const hideLoadingScreen = () => {
    loading_indicator.style.display = 'none';
    loading_warning.style.display = 'none';
}