import React, {useState, useEffect} from 'react';
import {useParams, useHistory} from 'react-router';
import axios from 'axios';
import {
    Link
    } from 'react-router-dom'

const OnePet=()=>{

    const {id} = useParams();
    const [petDetails, setPetDetails] = useState({});
    const history = useHistory(); //to redirect after deleting a ninja


    useEffect(()=>{
        axios.get(`http://localhost:8000/api/pets/${id}`)
        .then(res=>{
            console.log('response when making request for one pet')
            setPetDetails(res.data.results)
        })
        .catch(err=> console.log(err))
    }, [id])

    const deletePet = ()=>{
        console.log("deleting")
        axios.delete(`http://localhost:8000/api/pets/delete/${id}`)
            .then(res=>{
                console.log("response when deleting", res)
                history.push("/")
            })
            .catch(err=>console.log(err))
    }

    return(
        <div>
            <p><Link to={`/`}>back to home</Link></p>
            <h4>Details about: {petDetails.petName}</h4>
            <p>Type: {petDetails.petType}</p>
            <p>Description: {petDetails.petDescription}</p>
            <p>Skills:</p>
            <p>{petDetails.petSkill1}</p>
            <p>{petDetails.petSkill2}</p>
            <p>{petDetails.petSkill3}</p>
            <p>ID: {id}</p>
            <button onClick = {deletePet} className="btn btn-danger">Adopt Pet</button>
        </div>
    )
}

export default OnePet;