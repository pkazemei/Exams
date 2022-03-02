import React, {useState} from 'react';
import axios from 'axios'
import {useHistory} from "react-router";
import {
    Link
    } from 'react-router-dom'


const NewPetForm = (props) =>{

    let [petName, setPetName]= useState('');
    let [petType, setPetType]= useState('');
    let [petDescription, setPetDescription]= useState('');
    let[petSkill1, setPetSkill1]= useState('');
    let[petSkill2, setPetSkill2]= useState('');
    let[petSkill3, setPetSkill3]= useState('');

    let [formErrors, setFormErrors] = useState({})
    const history = useHistory();

const submitHandler=(e)=>{
    e.preventDefault();
    console.log(petName, petType, petDescription, petSkill1, petSkill2, petSkill3)
    let formInfoObj={petName, petType, petDescription, petSkill1, petSkill2, petSkill3}
    axios.post('http://localhost:8000/api/pets/new', formInfoObj)
        .then(res=>{
            console.log('response after posting', res)
            if(res.data.error){
                setFormErrors(res.data.error.errors)
            }else{
                props.setNewPetAdded(!props.newPetAdded)
                history.push("/");
            }
        })
        .catch(err=>console.log('error in submitting post request', err))
}

    return (
        <div>
            <p><Link to={`/`}>back to home</Link></p>
            <form onSubmit={submitHandler}>
                <div className='form-group'>
                    <label htmlFor=''>Name</label>
                    <input onChange={(e)=>(setPetName(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petName?.message}</p>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Type</label>
                    <input onChange={(e)=>(setPetType(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petType?.message}</p>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Description</label>
                    <input onChange={(e)=>(setPetDescription(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petDescription?.message}</p>
                </div>
                <div className='form-group'>
                    <h3>Skills (Optional)</h3>
                    <label htmlFor=''>Skill 1</label>
                    <input onChange={(e)=>(setPetSkill1(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petSkill1?.message}</p>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Skill 2</label>
                    <input onChange={(e)=>(setPetSkill2(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petSkill2?.message}</p>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Skill 3</label>
                    <input onChange={(e)=>(setPetSkill3(e.target.value))}type='text' name='' id='' className='form-control'></input>
                    <p className="text-danger">{formErrors.petSkill3?.message}</p>
                </div>
                <input type='submit' value='Add Pet' className='btn btn-success mt-3'></input>
            </form>
        </div>
    )
}

export default NewPetForm;