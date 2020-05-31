module.exports = (app) => {
    app.get('/', (req, res) => {
        res.render('index');
    });

    app.get('/about', (req, res) => {
        res.render('about');
    });

    app.get('/create', (req, res) => {
        res.render('create');
    });

    app.get('/details/:id', (req, res) => {
        res.render('details');
    });

    app.get('*', (req, res) => {
        res.render('404');
    });
};