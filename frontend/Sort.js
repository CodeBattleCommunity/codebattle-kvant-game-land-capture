document.addEventListener('DOMContentLoaded', () => {
  let elements = []
  let container = document.querySelector('#content')
  // Add each row to the array
  container.querySelectorAll('.row').forEach(el => elements.push(el))
  // Clear the container
  container.innerHTML = ''
  // Sort the array from highest to lowest
  elements.sort((a, b) => b.querySelector('.score').textContent - a.querySelector('.score').textContent)
  // Put the elements back into the container
  elements.forEach(e => container.appendChild(e))
})