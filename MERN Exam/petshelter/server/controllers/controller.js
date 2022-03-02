const Pet = require('../models/model');

module.exports.getAllPets = (req, res) => {
    console.log('trying to find all pets')
    Pet.find()
        .then(allPets =>{
            res.json({results: allPets})
        })
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

module.exports.getOnePet = (req, res) => {
    console.log('trying to find a pet')
    Pet.findOne({_id: req.params.id})
        .then(singlePet =>{
            res.json({results: singlePet})
        })
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

module.exports.createPet = (req, res) => {
    console.log('trying to create a pet')
        Pet.create(req.body)
        .then(newlyCreatedPet =>{
            res.json({results:newlyCreatedPet})
        })
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

module.exports.updatePet = (req, res) => {
    console.log('trying to update a pet')
    Pet.findOneAndUpdate(
        { _id: req.params.id },req.body, { new: true, runValidators: true })
        .then(updatedPet => res.json({ results: updatedPet }))
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}

module.exports.deletePet = (req, res)=>{
    console.log('trying to delete a pet')
    Pet.deleteOne({ _id: req.params.id })
        .then(deletedPet=>{
            res.json({ results: deletedPet })
        })
        .catch(err => res.json({ message: 'Something went wrong', error: err }));
}