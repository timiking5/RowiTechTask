buttons = document.querySelectorAll('.main-button');

buttons.forEach(element => element.addEventListener('click', postRemark));

async function postRemark(e) {
    
    button = e.target;
    buttonHolder = button.parentNode;
    inputs = buttonHolder.querySelectorAll('input');

    idHolder = inputs[0];
    remarkHolder = inputs[1];

    const response = await fetch(`/User/Home/PostRemark/?solutionId=${idHolder.value}&remarkText=${remarkHolder.value}`);
    if (response.status === 200) {
        card = buttonHolder.parentNode;
        remarkTextHolder = card.querySelectorAll('.text-dark, .text-opacity-50,  .pb-2')[1];
        remarkTextHolder.textContent = remarkHolder.value;
    }
}