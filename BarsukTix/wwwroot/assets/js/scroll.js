jQuery(document).ready(function(e){
    e.preventDefault;
    let hasCodeRun = false;
    setTimeout(function() {
        if (!hasCodeRun) {
            const root = document.documentElement;
            const marqueeElementsDisplayed = getComputedStyle(root).getPropertyValue("--marquee-elements-displayed");
            const marqueeContent = document.querySelector(".scroll-elements");
            root.style.setProperty("--marquee-elements", marqueeContent.children.length);
            for (let i = 0; i < marqueeElementsDisplayed; i++) {
                marqueeContent.appendChild(marqueeContent.children[i].cloneNode(true));
            }
            hasCodeRun = true;
        }
    }, 600);

    let textItemWrap = jQuery('.scroll-elements');
    let textItem = jQuery('.js-elements');
    for (let i = 0; i < 8; i++) {
        $(textItemWrap).append(textItem.clone());
    }
});