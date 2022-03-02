import React, {useState, useEffect} from 'react';
import axios from 'axios'
import { useHistory, useParams } from "react-router";
import {
    Link
    } from 'react-router-dom'

const EditPetForm = () =>{

    const { id } = useParams();

    //state variable to save the info i get back from api about one pet (or one object)
    let [petInfo, setPetInfo] = useState({
        petName:"",
        petType:"",
        petDescription:"",
        petSkill1:"",
        petSkill2:"",
        petSkill3:""
    })

    useEffect(()=>{
        axios.get(`http://localhost:8000/api/pets/${id}`)
        .then(res=>{
            console.log("response is this-->", res)
            setPetInfo(res.data.results)

        })
        .catch(err=> console.log(err))
    },[id])

    //initialize useHistory so we can redirect after the update of the form
    const history = useHistory();

    const changeHandler = (e)=>{
        console.log("changed in form detected!!")
        if(e.target.type === "checkbox"){
            setPetInfo({
                ...petInfo,
                [e.target.name]: e.target.checked
            })
        }else{
            setPetInfo({
                ...petInfo,
                [e.target.name]: e.target.value
            })

        }
    }

    const updateSubmitHandler = (e)=>{
        e.preventDefault();
        axios.put(`http://localhost:8000/api/pets/edit/${id}`, petInfo)
            .then(res=>{
                console.log("res after put request-->", res)
                history.push("/")
            })
            .catch(err=>console.log(err))

    }

    return (
        <div>
            <p><Link to={`/`}>back to home</Link></p>
            <h4>Edit {petInfo.petName}</h4>
            <form onSubmit={updateSubmitHandler}>
                <div className='form-group'>
                    <label htmlFor=''>Name</label>
                    <input type="text" name="petName" id="" className="form-control" value={petInfo.petName} onChange={changeHandler}/>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Type</label>
                    <input type="text" name="petType" id="" className="form-control" value={petInfo.petType} onChange={changeHandler}/>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Description</label>
                    <input type="text" name="petDescription" id="" className="form-control" value={petInfo.petDescription} onChange={changeHandler}/>
                </div>
                <div className='form-group'>
                <h3>Skills</h3>
                    <label htmlFor=''>Skill 1</label>
                    <input type="text" name="petSkill1" id="" className="form-control" value={petInfo.petSkill1} onChange={changeHandler}/>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Skill 2</label>
                    <input type="text" name="petSkill2" id="" className="form-control" value={petInfo.petSkill2} onChange={changeHandler}/>
                </div>
                <div className='form-group'>
                    <label htmlFor=''>Skill 3</label>
                    <input type="text" name="petSkill3" id="" className="form-control" value={petInfo.petSkill3} onChange={changeHandler}/>
                </div>
                <input type='submit' value='Update' className='btn btn-success mt-3'></input>
            </form>
        </div>
    )
}

export default EditPetForm;