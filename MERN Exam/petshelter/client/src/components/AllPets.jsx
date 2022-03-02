import React, {useState, useEffect} from 'react';
import axios from 'axios';
import {
    Link
    } from 'react-router-dom'

const AllPets =(props)=>{

    let [allPets, setAllPets]= useState([])

    useEffect(()=>{
        axios.get('http://localhost:8000/api/pets')
            .then(res=>{
                console.log('response when getting all pets', res)
                setAllPets(res.data.results)
            })
            .catch(err=>console.log('error', err))
    }, [props.newPetAdded])

    return(
        <div>
            <h3>These pets are looking for a good home</h3>
            <Link to='/new'>Add a pet to the shelter</Link>
            {allPets.map((petObj, i)=>{
                return(
                    <div key={i} style={{border:'1px solid black'}}>
                        <h4>Name: {petObj.petName}</h4>
                        <p>Type: {petObj.petType}</p>
                        <p><Link to={`/pets/edit/${petObj._id}`} className='btn btn-warning'>Edit</Link></p>
                        <p><Link to={`/pets/${petObj._id}`} className='btn btn-info'>Details</Link></p>
                    </div>
                )
            })}
        </div>
    )
}

export default AllPets;