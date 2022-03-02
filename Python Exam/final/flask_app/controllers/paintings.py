from flask_app import app
from flask import render_template, flash, session, redirect, request
from flask_app.models.user import User
from flask_app.models.painting import Painting

@app.route('/dashboard')
def dashboard():
    if 'user_id' not in session:
        flash("This page is only available to logged in users")
        return redirect('/')
    data={
        'id':session['user_id']
    }
    user=User.get_user_by_id(data)
    paintings=Painting.get_all_paintings()
    return render_template('paintings.html', paintings=paintings, user=user)
# Once logged in, takes user to dashboard

@app.route('/paintings/new')
def new_painting():
    if 'user_id' not in session:
        return redirect('/logout')
    data={
        'id':session['user_id']
    }
    user=User.get_user_by_id(data)
    return render_template('new_painting.html', user=user)
# Returns to create painting screen

@app.route('/paintings/create', methods=['POST'])
def create_painting():
    if 'user_id' not in session:
        return redirect('/logout')
    if not Painting.validate_painting(request.form):
        return redirect('/paintings/new')
    data={
        'title':request.form['title'],
        'description':request.form['description'],
        'price':request.form['price'],
        'creator_id':session['user_id']
        }
    Painting.create_new_painting(data)
    return redirect('/dashboard')
# Create painting

@app.route('/paintings/<int:id>')
def single_painting_data(id):
    if 'user_id' not in session:
        return redirect('/logout')
    data={
        'id':id
    }
    user_data={
        'id':session['user_id']
    }
    user=User.get_user_by_id(user_data)
    painting=Painting.get_painting_by_id(data)
    return render_template('single_painting.html', painting=painting, user=user)
# View single painting

@app.route('/paintings/<int:id>/delete')
def delete_painting(id):
    if 'user_id' not in session:
        return redirect('/logout')
    data={
        'id':id
        }
    Painting.delete_painting(data)
    return redirect ('/dashboard')
# Prevent unauthorized user from deleting single painting

@app.route('/paintings/<int:id>/edit')
def edit_painting(id):
    if 'user_id' not in session:
        return redirect('/logout')
    data={
        'id':id
    }
    user_data={
        'id':session['user_id']
    }
    user=User.get_user_by_id(user_data)
    painting=Painting.get_painting_by_id(data)
    return render_template('edit_painting.html', painting=painting, user=user)
# Edit single painting

@app.route('/paintings/<int:id>/update', methods=['POST'])
def update_painting(id):
    if 'user_id' not in session:
        return redirect('/logout')
    if not Painting.validate_painting(request.form):
        return redirect ('/paintings/new')
    data={
        'title':request.form['title'],
        'description':request.form['description'],
        'price':request.form['price'],
        'id':id
    }
    Painting.update_painting(data)
    return redirect(f'/paintings/{id}')