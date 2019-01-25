function solve() {
   let buttons = Array.from(document.getElementsByTagName('button'));

   buttons.forEach(btn => {
      btn.addEventListener('click', event => {
         let profile = event.target;
         let currentProfile = profile.parentNode;
         let element = currentProfile.getElementsByTagName('input')[0];

         if (!element.checked) {
            let hiddenElements = currentProfile.querySelector('[id$="HiddenFields"]');
            let buttonContent = currentProfile.getElementsByTagName('button')[0];

            if (buttonContent.textContent === 'Show more') {
               hiddenElements.style.display = 'block';
               buttonContent.textContent = 'Hide it';
            }
            else {
               hiddenElements.style.display = 'none';
               buttonContent.textContent = 'Show more';
            }
         }
      });
   });
} 