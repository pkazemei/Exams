//import controller
const PetController=require('../controllers/controller')

module.exports = app =>{
    app.get('/api/pets', PetController.getAllPets)
    app.post('/api/pets/new', PetController.createPet)
    app.get('/api/pets/:id', PetController.getOnePet)
    app.put('/api/pets/edit/:id', PetController.updatePet)
    app.delete('/api/pets/delete/:id', PetController.deletePet)
}