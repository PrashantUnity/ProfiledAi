function hideSidebar() {
    document.querySelector('.sidebar')?.classList.remove('active');
}

function hideSidebarOnMobile() {
    if (window.innerWidth < 768) {
        document.querySelector('.sidebar')?.classList.remove('active');
    }
}

function showSidebarOnMobile() {
    if (window.innerWidth < 768) {
        document.querySelector('.sidebar')?.classList.add('active');
    }
}
function getWindowSize() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
}
