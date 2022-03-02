const mongoose = require('mongoose'); //import mongoose

const PetSchema = new mongoose.Schema({
    petName: {
        type: String,
        required: [true, 'Pet Name is required'],
        minlength: [3, 'Pet Name must be at least 3 characters']
    },
    petType: {
        type: String,
        required: [true, 'Pet Type is required'],
        minlength: [3, 'Pet Type must be at least 3 characters']
    },
    petDescription: {
        type: String,
        required: [true, 'Pet Description is required'],
        minlength: [3, 'Pet Description must be at least 3 characters']
    },
    petSkill1: {
        type: String
    },
    petSkill2: {
        type: String
    },
    petSkill3: {
        type: String
    }
});

const Pet = mongoose.model('Pet', PetSchema);

module.exports = Pet;