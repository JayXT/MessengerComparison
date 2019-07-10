# MessengerComparison
Project aimed at providing thorough comparison of Telegram, Viber and WhatsApp messengers.
This repository is currently targetting Ukrainian, English and Russian localization.
The comparison table is available via following URLs:

- https://messenger-comparison.azurewebsites.net/en

- https://jayxt.github.io/MessengerComparison/en

Current Maintainers:
- JayXT: EN, UA
- Hookz: RU


If you want to create the new translation or project based on this repository, feel free to use one of the following approaches:

1) **Independent Project**: create a fork of JayXT/MessengerComparison repository, remove redundant translations, update README.md accordingly and continue restructuring the project to serve your purposes (e.g. comparing different set of messengers). If your page contains more then ~25% of original text, markup or CSS styles, please include reference to this repository in your pages to show that your project reuses the developments of JayXT/MessengerComparison.

2) **Independent Translation**: create a fork of JayXT/MessengerComparison repository, remove redundant translations, update README.md accordingly and simply translate the new page inside of your repository. You can continue development and maintenance of the new translation on your own, but please do not change the meaning of table comparison values and criterias. The page will not be included in the list of language references of JayXT/MessengerComparison.

3) **External Translation**: create a fork of JayXT/MessengerComparison repository, remove redundant translations, update README.md file to show what language or languages the new repository is targetting at and who are the current maintainer(s) of your translation(s). Do not include maintainers of this repository in your list. Then update your translations to match the original repository structure and requirements. Finally notify us about your translation. If everthing looks fine, we will include a link to your page in pages from JayXT/MessengerComparison. This approach will allow you to make corrections to your translation without pull requests, but obviously it will belong to GitHub Pages domain of your repository.

4) **Integrated Translation**: become a contributor of this repository by creating separate git branch for your translation. Perform the translation of the page in the branch and as soon as it matches repository structure and requirements, create pull request into master branch.  It will be approved and merged, the page will be included in this repository. This approach will require approving and merging pull requests by repository owner, but the translation will be hosted on GitHub Pages domain of this repository.


For **External Translation** and **Integrated Translation** approaches please make sure that:

1) Your page markup doesn't include any HTML tags or attributes that are not included in the English/Ukrainian page and has exactly the same HTML structure.
2) All attributes and CSS classes are applied correctly, especially pay attention to advantage, disadvantage and mediocrity cells.
3) All columns have the same width as in other translations.
4) Your translation is accurate enough and upper/lower-case letters are applied the same way as in original page.

To get approval of pull request into this repository's master branch, please apply changes only to [your_language]/index.html file. Other files as README.md and en/index.html, ru/index.html and index.html etc. should be left without changes and not included in pull request.
In case if your [your_language]/index.html meets all conditions the pull request will get approved, the page will be included in main repository and both README.md and all pages will get updated by me or respective translation maintainers to contain a link to your page.

