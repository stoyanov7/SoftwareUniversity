function solve(selector) {
     const htmlElement = document.querySelector(selector);
     htmlElement.classList.add('highlight');

     highlightChildren(htmlElement);

     function highlightChildren(element) {
          const children = element.children;

          if (children.length === 0) {
               return;
          }

          for (let i = 0; i < children.length; i++) {
               highlightChildren(children[i]);
               children[i].classList.add('highlight');
          }
     }
}