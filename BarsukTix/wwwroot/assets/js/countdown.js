// ===================== For Demo Server(Add 9 Days with current date) =====================

function updateTargetDate() {
  const now = new Date();
  now.setHours(23, 59, 59, 0);
  const targetDate = now.getTime() + 10 * 24 * 60 * 60 * 1000;
  return targetDate;
}
function updateCountdown() {
  const targetDate = updateTargetDate();
  const now = new Date().getTime();
  const timeLeft = targetDate - now;
  const days = Math.floor(timeLeft / (1000 * 60 * 60 * 24));
  const hours = Math.floor((timeLeft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
  const minutes = Math.floor((timeLeft % (1000 * 60 * 60)) / (1000 * 60));
  const seconds = Math.floor((timeLeft % (1000 * 60)) / 1000);
  document.getElementById("days").textContent = days < 10 ? "0" + days : days;
  document.getElementById("hours").textContent = hours < 10 ? "0" + hours : hours;
  document.getElementById("minutes").textContent = minutes < 10 ? "0" + minutes : minutes;
  document.getElementById("seconds").textContent = seconds < 10 ? "0" + seconds : seconds;
}
setInterval(updateCountdown, 1000);
updateCountdown();

// ===================== For Demo Server(Add 9 Days with current date) =====================